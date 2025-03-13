using System.Master.Loyalty.Group.Data.Repositories.Branch;
using System.Master.Loyalty.Group.Data;
using System.Master.Loyalty.Group.Entities.Branch;
using System.Master.Loyalty.Group.Entities;
using System.Master.Loyalty.Group.Entities.Article;
using System.Master.Loyalty.Group.Data.Repositories.Article;
using Azure.Core;
using System.Master.Loyalty.Group.Bussiness.Common;
using Microsoft.AspNetCore.Http;

namespace System.Master.Loyalty.Group.Bussiness.Article
{
    public class ArticleBussiness : IArticleBussiness
    {
        private readonly IArticleRepository articleRepository;
        private readonly IHttpContextUtility httpContextUtility;
        public ArticleBussiness(IArticleRepository articleRepository, IHttpContextUtility httpContextUtility)
        {
            this.articleRepository = articleRepository;
            this.httpContextUtility = httpContextUtility;
        }

        public async Task<BaseResponse> Create(ArticleRequest request)
        {
            var result = new BaseResponse() { };

            var fileExtension = Path.GetExtension(request.ImageName);
            var fileName = Guid.NewGuid().ToString().Replace("-", "");
            var newFileSave = $"{fileName}{fileExtension}";

            var path = Path.Combine(httpContextUtility.GetWebRootPath(), "img/product");

            if (request.Image != null)
            {
                var resultSave = SaveFormFile(request.Image, newFileSave, path);

                if (resultSave)
                {
                    var fileUrl = Path.Combine("img/product", newFileSave).Replace("\\", "/");

                    var item = new ArticleData()
                    {
                        Name = request.Name,
                        Code = request.Code,
                        Description = request.Description,
                        Price = request.Price,
                        ImageName = newFileSave,
                        ImageUrl = fileUrl
                    };

                    result.IsSuccess = await this.articleRepository.Create(item);
                    result.MessageError = result.IsSuccess == false ? "Error al guardar artículo, por favor, comunícate con el administrador" : string.Empty;
                }
                else
                {
                    result.IsSuccess = false;
                    result.MessageError = "Error al generar el producto, por favor, comunícate con el administrador ";
                }
            }


            return result;
        }

        public async Task<BaseResponse> Delete(int branchId)
        {

            var result = await this.articleRepository.Delete(branchId);

            return new BaseResponse()
            {
                IsSuccess = result
            };

        }

        public async Task<List<ArticleResponse>> ReadAll()
        {
            var result = (await this.articleRepository.ReadAll()).Select(element => new ArticleResponse()
            {
                Id = element.Id,
                Name = element.Name,
                Code = element.Code,
                Description = element.Description,
                Price = element.Price,
                ImageName = element.ImageName,
                ImageUrl = element.ImageUrl != null ? Path.Combine(httpContextUtility.GetBaseUrl(), element.ImageUrl).Replace("\\", "/") : ("")
            }).ToList();

            return result;
        }

        public async Task<BaseResponse> Update(ArticleRequest request)
        {
            var result = new BaseResponse() { };

            var fileExtension = Path.GetExtension(request.ImageName);
            var fileName = Guid.NewGuid().ToString().Replace("-", "");
            var newFileSave = $"{fileName}{fileExtension}";

            var path = Path.Combine(httpContextUtility.GetWebRootPath(), "img/product");

            if (request.Image != null)
            {
                var resultSave = SaveFormFile(request.Image, newFileSave, path);

                if (resultSave)
                {
                    var fileUrl = Path.Combine("img/product", newFileSave).Replace("\\", "/");

                    var item = new ArticleData()
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Code = request.Code,
                        Description = request.Description,
                        Price = request.Price,
                        ImageName = newFileSave,
                        ImageUrl = fileUrl
                    };

                    result.IsSuccess = await this.articleRepository.Update(item);
                    result.MessageError = result.IsSuccess == false ? "Error al guardar artículo, por favor, comunícate con el administrador" : string.Empty;
                }
                else
                {
                    result.IsSuccess = false;
                    result.MessageError = "Error al generar el producto, por favor, comunícate con el administrador ";
                }
            }

            return result;
        }

        private bool SaveFormFile(IFormFile formFile, string fileName, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return true;
        }
    }
}
