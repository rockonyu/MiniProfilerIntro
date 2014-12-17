using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProfilerIntro.Models.api {
    public class apiTrack {
        public long Id { get; set; }

        public string Name { get; set; }

        public apiArtist Artist { get; set; }

        public int Number { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}