using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents
{
    public class BottomNavigationViewComponent : ViewComponent
    {
        public BottomNavigationViewComponent()
        {
        }

        public ValueTask<IViewComponentResult> InvokeAsync()
        {
            return new ValueTask<IViewComponentResult>(View());
        }
    }
}
