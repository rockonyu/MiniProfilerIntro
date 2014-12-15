using MiniProfilerIntro.Models;
using MiniProfilerIntro.Models.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiniProfilerIntro.Controllers.api
{
    public class TrackController : ApiController
    {
        private itunesdataEntities db = new itunesdataEntities();

        public IEnumerable<apiTrack> Get() {

            var query = db.Track.Select(m => new apiTrack { Id = m.Id, Name = m.Name, Number = m.Number, ReleaseDate = m.ReleaseDate, Artist = new apiArtist { Name = m.Artist.Name } })
                .OrderBy(m => m.Id).Take(100).ToList();

            return query;
        }

        public apiTrack Get(int id) {
            return db.Track.Select(m => new apiTrack { Id = m.Id, Name = m.Name, Number = m.Number, ReleaseDate = m.ReleaseDate, Artist = new apiArtist { Name = m.Artist.Name } })
                .FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<apiTrack> Get(string name) {
            return db.Track.Select(m => new apiTrack { Id = m.Id, Name = m.Name, Number = m.Number, ReleaseDate = m.ReleaseDate, Artist = new apiArtist { Name = m.Artist.Name } })
                .Where(m => m.Name.Contains(name)).OrderBy(m => m.Id).Take(100).ToList();
        }
    }
}
