using System.Collections.Generic;
using WebPoll.Model.Models;

namespace WebPoll.Service.Test.TestContainer
{
    public class ArtistRepositoryTestContainer : TestContainer<Artist>
    {
        public override void SetDictionary()
        {
            Dictionary = new Dictionary<RepositoryOperations, Artist>();
            Dictionary.Add(RepositoryOperations.INSERT, new Artist { Name = "insert" });
            Dictionary.Add(RepositoryOperations.UPDATE, new Artist { Name = "update" });
            Dictionary.GetValueOrDefault(RepositoryOperations.INSERT);
        }
    }
}
