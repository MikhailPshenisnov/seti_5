using Microsoft.AspNetCore.Mvc;
using org.mariuszgromada.math.mxparser;

namespace seti5.Controllers;

[ApiController]
[Route("/[action]")]
public class TestController : ControllerBase
{
    [HttpPost("{expression=}")]
    public IActionResult SolveExpression(string expression)
    {
        try
        {
            var e = new Expression(expression);
            var result = e.getExpressionString() + " = " + e.calculate();
            return Ok(result);
        }
        catch (Exception exception)
        {
            return Ok(exception.Message);
        }
    }
}