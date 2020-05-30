using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities  {
    public class GraduateAlbum : Entity{
        public GraduateAlbum() {
            GraduateAlbumId = Guid.NewGuid().ToString();
        }

        public string GraduateAlbumId { get; set; }
        public string AlbumCode { get; set; }
        public int AmountPhotosAvailable { get; set; }
        public int AmountPhotosScraps { get; set; }
        public int AmountPhotosSold { get; set; }

        public string GraduateId { get; set; }
        public string ContractId { get; set; }

        public Graduate Graduate { get; set; }
        public Contract Contract { get; set; }
    }
}
