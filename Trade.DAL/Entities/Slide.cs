﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.DAL.Entities
{
    public class Slide
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Slogan")]
        public string Slogan { get; set; }

        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Slayt Başlığı"), Required(ErrorMessage = "Slayt Başlığı Boş Geçilemez")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(250)"), StringLength(250), Display(Name = "Slayt Açıklaması"), Required(ErrorMessage = "Slayt Açıklaması Boş Bırakılamaz")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(150)"), StringLength(150), Display(Name = "Resim Dosyası")]
        public string Picture { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Fiyat Bilgisi")]
        public decimal Price { get; set; }

        [Column(TypeName = "varchar(150)"), StringLength(150), Display(Name = "Link Adresi")]
        public string Link { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }
    }
}
