﻿using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace UdemyAspNetCore1.Models
{
    //DataAnnatatoin
    public class Customer
    {
        [Required(ErrorMessage ="Id alanı gereklidir")]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        [MaxLength(30,ErrorMessage ="Ad alanı en fazla 30 karakter olabilir")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [MinLength(3,ErrorMessage = "\"Soyad alanı en az 3 karakter olabilir")]
        public string LastName { get; set; }
        [Range(18,40,ErrorMessage ="Yaş değeri en az 18 , en fazla 40 olabilir")]
        public int Age { get; set; }
    }
}
