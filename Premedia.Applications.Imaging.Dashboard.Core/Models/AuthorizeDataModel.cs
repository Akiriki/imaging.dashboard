//using Premedia.Applications.Imaging.Dashboard.Core.Enums;

namespace Premedia.Applications.Imaging.Dashboard.Core.Models;

public class AuthorizeDataModel
{
    public AuthorizeDataModel()
    {
    }

   /* public AuthorizeDataModel(TokenDataModel data, string hash,
        int? impersonateUserId = null, int? externalUserId = null)
    {
        Data = data;
        Hash = hash;
        if (impersonateUserId != null)
        {
            ImpersonateUserId = impersonateUserId;
            UserType = UserType.ImpersonateUser;
        }

        if (externalUserId != null)
        {
            ExternalUserId = externalUserId;
            UserType = UserType.ExternalUser;
        }
    }

    public TokenDataModel Data { get; set; }
    public string Hash { get; set; }
    public UserType UserType { get; set; } = UserType.Default;
    public int? ImpersonateUserId { get; set; }
    public int? ExternalUserId { get; set; }*/
}