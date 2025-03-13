namespace System.Master.Loyalty.Group.Bussiness.Common
{
    public interface IHttpContextUtility
    {
        string GetBaseUrl();

        string GetWebRootPath();

        System.Security.Claims.ClaimsPrincipal GetCurrentUser();
    }

}
