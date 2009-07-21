using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dimebrain.TweetSharp.Model;

namespace TwitsNearby.Models
{
    public interface IStatusesService
    {

       TwitterStatus AddStatuses(double? lat, double? lng, string text, long replyTo);

       void AddStatusesToOwnDB(Guid id, long statusid, double? lat, double? lng, string text);

       Statuses RetrieveStatusesFromOwnDB(Guid id);

       Statuses RetrieveStatusesFromOwnDB(long tweetid);

       IList<TwitterStatus> RetrieveStatusesByUser(string userid);

       IList<TwitterStatus> RetrieveStatusesByUser(OAuthToken access);

       void FormatTweetForNearBy(IList<TwitterStatus> statuses);
    }
}
