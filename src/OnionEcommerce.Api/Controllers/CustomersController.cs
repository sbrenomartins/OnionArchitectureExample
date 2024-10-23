namespace OnionEcommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerApplicationService _customerApplicationService;

    public CustomersController(ICustomerApplicationService customerApplicationService)
    {
        _customerApplicationService = customerApplicationService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] CustomerDTO customerDTO)
    {
        try
        {
            _customerApplicationService.Create(customerDTO);
            return Created("", customerDTO);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("already in use."))
            {
                return Conflict(ex.Message);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Read()
    {
        try
        {
            var customers = _customerApplicationService.Read();
            return Ok(customers);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Read(string id)
    {
        try
        {
            var formattedId = Uri.UnescapeDataString(id);
            var customer = _customerApplicationService.Read(formattedId);

            if (customer is null) return NotFound();

            return Ok(customer);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update([FromBody] CustomerDTO customerDTO)
    {
        try
        {
            _customerApplicationService.Update(customerDTO);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(string id)
    {
        try
        {
            var formattedId = Uri.UnescapeDataString(id);
            _customerApplicationService.Delete(formattedId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
