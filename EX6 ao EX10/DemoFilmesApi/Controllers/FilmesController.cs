using DemoFilmesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoFilmesApi.Controllers
{
    [Route("api/v{version:apiVersion}/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        // GET: api/<FilmesController>

        /// <summary>
        /// Lista mocada de filmes
        /// </summary>
        /// <returns>Retorna uma lista mocada de filmes</returns>
        /// <response code="200">Com a lista de filmes presentes na base de dados</response>
        
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet]
        public IEnumerable<Filme> Get()
        {
            return MockFilmes.Filmes;
        }

        // GET api/<FilmesController>/5
        /// <summary>
        /// Recupera um filme no banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id do filme a ser recuperado no banco</param>
        /// <returns>Informações do filme buscado</returns>
        /// <response code="200">Caso o id seja existente na base de dados</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Filme filme = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);
            if (filme is null)
            {
                return NotFound();
            }

            return Ok(filme);
        }


        // POST api/<FilmesController>

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filme">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>Dados do filme cadastrado</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        
        [ProducesResponseType(StatusCodes.Status201Created)]

        [HttpPost]
        public IActionResult Post([FromBody] Filme filme)
        {
            return CreatedAtAction(nameof(Get), new
            {
                id
             = filme.Id
            }, filme);
        }

        // PUT api/<FilmesController>/5

        /// <summary>
        /// Atualiza um filme no banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id do filme a ser atualizado no banco</param>
        /// <param name="filme">Objeto com os campos necessários para atualização de um filme</param>
        /// <returns>Sem conteúdo de retorno</returns>
        /// <response code="204">Caso o id seja existente na base de dados e o filme tenha sido atualizado</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
       
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Filme filme)
        {
            Filme filmeUpdate = MockFilmes.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filmeUpdate != null)
            {
                var index = MockFilmes.Filmes.IndexOf(filmeUpdate);

                if (index != -1)
                    MockFilmes.Filmes[index] = filme;

                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/<FilmesController>/5

        /// <summary>
        /// Deleta um filme usando seu id
        /// </summary>
        /// <param name="id">Id do filme a ser removido da base de dados</param>
        /// <returns>Sem conteúdo de retorno</returns>
        /// <response code="204">Caso o id seja existente na base de dados e o filme tenha sido removido</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Filme filmeUpdate = MockFilmes.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filmeUpdate is not null)
            {
                MockFilmes.Filmes.Remove(filmeUpdate);

                return NoContent();
            }

            return NotFound();
        }
    }
}
