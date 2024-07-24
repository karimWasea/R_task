using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

using System.Threading.Tasks;

using ViewModel.MailSeting;

public class MailingController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public MailingController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult SendMail()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMail(MailRequestVM mailRequestVM)
    {
        if (!ModelState.IsValid)
        {
            return View(mailRequestVM);
        }

        await _unitOfWork._mailingService.SendEmailAsync(mailRequestVM);
        ViewBag.Message = "Email sent successfully!";
        return View(new MailRequestVM());
    }

    public IActionResult Index()
    {
        // Logic to return to the index or list view
        return View();
    }
}
