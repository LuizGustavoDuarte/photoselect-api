package com.photoselect.api.Controllers;


import com.photoselect.api.DTO.PhotoDTO;
import com.photoselect.api.Services.PhotoService;
import lombok.AllArgsConstructor;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.*;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import static java.nio.file.StandardCopyOption.REPLACE_EXISTING;

@AllArgsConstructor
@RestController
@RequestMapping("/photo")
public class PhotosController {
    private PhotoService photoService;

    @GetMapping("/{photoId}")
    public ResponseEntity<PhotoDTO> getPhoto(@PathVariable UUID photoId) {
        return ResponseEntity.ok(new PhotoDTO(UUID.randomUUID(), "photo.png"));
    }

    @PostMapping()
    public ResponseEntity<List<PhotoDTO>> uploadPhoto(@RequestParam("photos") List<MultipartFile> photos) {
        List<PhotoDTO> uploadedPhotos = photoService.upload(photos);
        return ResponseEntity.ok(uploadedPhotos);
    }
}
