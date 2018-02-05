using Library.Core.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Library.Web.Models
{
    public class AddBookViewModel : BooksViewModel
    {
        public List<SelectListItem> Categories { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Drama", Value = "Drama" },
            new SelectListItem { Text = "Romance", Value = "Romance" },
            new SelectListItem { Text = "Horror", Value = "Horror" },
            new SelectListItem { Text = "Fantasy", Value = "Fantasy" },
            new SelectListItem { Text = "Crime story", Value = "Crime story" },
        };

        public AddBookViewModel()
        {
        }

        public AddBookViewModel(BookDto bookDto) : base (bookDto)
        {
        }
    }
}
