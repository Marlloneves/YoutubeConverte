YouTube Downloader API em .NET 7.0
Esta é uma API assíncrona em .NET 7.0 que utiliza o YouTubeClient para obter os dados de vídeo do YouTube e realizar o download e conversão para áudio. A API fornece um método simples para iniciar o download de áudio de um vídeo do YouTube, bastando fornecer parte da URL do vídeo.

Pré-requisitos
* SDK .NET 7.0 ou superior instalado na máquina de desenvolvimento.
* URL do vídeo que deseja realizar a conversão.

Instalação
* Clone este repositório em sua máquina local.
* Abra o projeto em seu ambiente de desenvolvimento preferido (por exemplo, Visual Studio, Visual Studio Code).

Uso
* Compile e inicie o projeto da API.
* Acesse a rota adequada para iniciar o processo de download. Por exemplo: HTTPGET GetUrlVideo(string videoId)
* Substitua 'videoId' pela parte da URL do vídeo do Youtube que você deseja baixar.
* Aguarde até que o download e a conversão para áudio sejam concluídos.
* O arquivo de áudio resultante estará disponível para download ou pode ser manipulado conforme necessário.

Contribuição
Contribuições são bem-vindas! Se você encontrar algum problema ou desejar melhorar este projeto de alguma forma, sinta-se à vontade para abrir uma issue ou enviar um pull request.