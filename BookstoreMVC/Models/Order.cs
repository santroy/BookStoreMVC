using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookstoreMVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string UserID { get; set;}
        public virtual ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzic imię")]
        [StringLength(150)]
        public string FirstName { get; set;}

        [Required(ErrorMessage = "Musisz wprowadzić nazwisko")]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzic adres")]
        [StringLength(150)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Musisz kod pocztowy")]
        [StringLength(50)]
        public string CityCode { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzic numer tel")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+",
            ErrorMessage = "Bledny numer telefonu.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Wprowadz adres e-mail")]
        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail")]
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }


    public enum OrderState {
        New, Shipped
    }


}