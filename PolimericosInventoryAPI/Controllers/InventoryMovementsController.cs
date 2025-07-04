using Microsoft.AspNetCore.Mvc;
using PolimericosInventoryAPI.DTOs;
using PolimericosInventoryAPI.Interfaces;

namespace PolimericosInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryMovementsController : ControllerBase
    {
        private readonly IInventoryMovementService _inventoryMovementService;
        public InventoryMovementsController(IInventoryMovementService inventoryMovementService)
        {
            _inventoryMovementService = inventoryMovementService;
        }

        // GET: api/inventorymovements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryMovementDTO>>> GetAll()
        {
            var movements = await _inventoryMovementService.GetAllAsync();
            return Ok(movements);
        }

        // GET: api/inventorymovements/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryMovementDTO>> GetById(int id)
        {
            var movement = await _inventoryMovementService.GetByIdAsync(id);
            if (movement == null) return NotFound();
            return Ok(movement);
        }

        // POST: api/inventorymovements
        [HttpPost]
        public async Task<ActionResult<InventoryMovementDTO>> Create([FromBody] InventoryMovementCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newMovement = await _inventoryMovementService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newMovement.Id }, newMovement);
        }
    }
}
