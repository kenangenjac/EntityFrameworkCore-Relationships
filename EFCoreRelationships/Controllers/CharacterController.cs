using EFCoreRelationships.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get all the Characters with the given userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Characters</returns>
        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(c => c.UserId == userId)
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .ToListAsync();

            return characters;
        }

        /// <summary>
        /// Method that creates a new Character with a Dto of Character provided
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List of Characters</returns>
        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CreateCharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newCharacter = new Character
            {
                Name = request.Name,
                RpgClass = request.RpgClass,
                User = user
            };

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }

        /// <summary>
        /// Method that creates a new Weapon with a Dto of Weapons provided
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Character object</returns>
        [HttpPost("newWeapon")]
        public async Task<ActionResult<Character>> CreateWeapon(CreateWeaponDto request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
                return NotFound();

            var newWeapon = new Weapon
            {
                Name = request.Name,
                Damage = request.Damage,
                Character = character
            };

            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return character;
        }

        /// <summary>
        /// Method that adds a new Skill to a Character with a Dto provided
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Character object</returns>
        [HttpPost("addSkill")]
        public async Task<ActionResult<Character>> AddCharacterSkill(AddCharacterSkillDto request)
        {
            var character = await _context.Characters
                .Where(c => c.Id == request.CharacterId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();

            if (character == null)
                return NotFound();

            var skill = await _context.Skills.FindAsync(request.SkillId);
            if (skill == null) 
                return NotFound();

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}
