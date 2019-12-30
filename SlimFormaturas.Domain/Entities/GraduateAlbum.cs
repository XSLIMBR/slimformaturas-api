using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities  {
    public class GraduateAlbum : Entity{
        public GraduateAlbum() {
            GraduateAlbumId = Guid.NewGuid().ToString();
        }

        public GraduateAlbum(string graduateAlbumId, string albumCode, int amountPhotosAvailable, int amountPhotosScraps, int amountPhotosSold) {
            GraduateAlbumId = graduateAlbumId;
            AlbumCode = albumCode;
            AmountPhotosAvailable = amountPhotosAvailable;
            AmountPhotosScraps = amountPhotosScraps;
            AmountPhotosSold = amountPhotosSold;
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
