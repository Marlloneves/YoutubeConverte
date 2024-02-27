using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NReco.VideoConverter;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeConverter.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {

        [HttpGet("{videoId}")]
        public async Task<ActionResult> GetUrlVideo(string videoId)
        {
            var client = new YoutubeClient();
            try
            {
                var video = await client.Videos.GetAsync(videoId);
                var streams = await client.Videos.Streams.GetManifestAsync(videoId);

                var audioOnly = streams.GetAudioOnlyStreams().GetWithHighestBitrate();

                var converter = new FFMpegConverter();
                var audioOutputPath = Path.Combine(Environment.CurrentDirectory, $"{videoId}_audio.mp3"); // Alterado para .mp3

                // Baixar o áudio
                await client.Videos.Streams.DownloadAsync(audioOnly, audioOutputPath);

                // Converter o áudio usando FFMpegConverter
                converter.ConvertMedia(audioOutputPath, audioOutputPath.Replace(".mp3", "_converted.mp3"), Format.mp4); // Alterado para .mp3

                // Retornar o caminho do arquivo de áudio convertido
                return Ok(new { AudioFilePath = audioOutputPath.Replace(".mp3", "_converted.mp3") }); // Alterado para .mp3
            }
            catch (Exception e)
            {
                // Capturar a exceção e imprimir a mensagem de erro
                Console.WriteLine($"Erro na conversão: {e.Message}");
                return BadRequest($"Erro na conversão: {e.Message}");
            }

            return Ok();
        }
    }
}
