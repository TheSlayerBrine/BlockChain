﻿namespace Service.Service.Blob;

public class BlobResponseDto
{
    public BlobResponseDto()
    {
        Blob = new BlobDto();
    }
    public string? Status { get; set; }
    public BlobDto Blob { get; set; }
    public bool Error { get; set; }
}