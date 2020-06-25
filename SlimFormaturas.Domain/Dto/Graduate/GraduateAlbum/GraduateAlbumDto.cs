using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Dto.Graduate.GraduateAlbum {
    public class GraduateAlbumDto {
        public string GraduateAlbumId { get; set; }
        public string AlbumCode { get; set; }
        public int AmountPhotosAvailable { get; set; }
        public int AmountPhotosScraps { get; set; }
        public int AmountPhotosSold { get; set; }

        public GraduateDto Graduate { get; set; }
        //public ContractDto Contract { get; set; }
    }
}
