using System;
using Microsoft.AspNetCore.Mvc;
using MongoCrud.Models;
using MongoCrud.Services;

namespace MongoCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase 
{
    private readonly MongoDBService _mongoDBService;

    public CommentsController(MongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Comment>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Comment newComment) {
        await _mongoDBService.CreateAsync(newComment);
        return CreatedAtAction(nameof(Get), new { id = newComment.Id }, newComment );
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> AddToComment(string id, [FromBody] string movieId) {}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }


}
