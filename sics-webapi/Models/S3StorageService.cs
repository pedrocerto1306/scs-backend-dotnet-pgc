namespace sics_webapi.Models;

using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using sics_webapi.Models.Interfaces;

public class S3StorageService : IS3StorageService
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3StorageService(IAmazonS3 s3Client, IConfiguration configuration)
    {
        _s3Client = s3Client;
        _bucketName = configuration["S3:BucketName"] ?? "sics-assets";
    }

    public async Task<string> UploadFileAsync(string key, Stream content, string contentType)
    {
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = key, // O caminho e nome do arquivo no S3 (ex: "imagens/foto.jpg")
            InputStream = content,
            ContentType = contentType // O tipo MIME do arquivo (ex: "image/jpeg", "application/pdf")
        };

        PutObjectResponse response = await _s3Client.PutObjectAsync(putObjectRequest);

        // Você pode retornar a URL do objeto ou alguma outra informação útil
        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            // Note: Para obter a URL pública, você precisaria de um ClientConfig com Use<ctrl61>HttpHostName=true
            // ou construir a URL manualmente se o bucket for público.
            // Para buckets privados, a URL direta não funcionará sem presigned URLs.
            return $"https://{_bucketName}.s3.amazonaws.com/{key}";
        }
        else
        {
            throw new Exception($"Falha ao fazer upload para o S3: {response.HttpStatusCode}");
        }
    }
}