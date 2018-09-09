using System.Collections.Generic;
using ClArc.Sync.Core;
using UseCase.Users.Commons;

namespace UseCase.Users.GetList
{
    public class UserGetListResponse : IResponse
    {
        public UserGetListResponse(List<UserSummary> summaries) {
            Summaries = summaries;
        }

        public List<UserSummary> Summaries { get; }
    }
}
