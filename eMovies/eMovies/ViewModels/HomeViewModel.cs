using Microsoft.AspNetCore.Mvc;

namespace eMovies.ViewModels
{
    public class HomeViewModel
    {
        public TopUpcommingMoviesViewModel TopUpcommingMovies { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
    }
}
