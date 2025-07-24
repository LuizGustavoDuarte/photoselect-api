package com.photoselect.api.Services;

import com.photoselect.api.DTO.PhotoDTO;
import com.photoselect.api.Entities.PhotoEntity;
import com.photoselect.api.Repositories.PhotoRepository;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

@Service
@AllArgsConstructor
public class PhotoService {
    private PhotoRepository photoRepository;

    public List<PhotoDTO> upload(List<MultipartFile> photos) {
        List<File> photoFiles = new ArrayList<>();
        List<PhotoDTO> photoDTOs = new ArrayList<>();
        List<PhotoEntity> photoEntities = new ArrayList<>();
        for (MultipartFile photo : photos) {
            File file = new File(photo.getOriginalFilename());
            try {
                photo.transferTo(file);
            } catch (IOException e) {
                System.out.println("Unable to read file: " + photo.getName());
                e.printStackTrace();
            }
            photoFiles.add(file);
            PhotoDTO currentPhotoDTO = new PhotoDTO(UUID.randomUUID(), photo.getOriginalFilename());
            photoDTOs.add(currentPhotoDTO);
            photoEntities.add(new PhotoEntity(currentPhotoDTO.getId(), currentPhotoDTO.getFilename(), file.getPath()));
        }

        List<PhotoEntity> entities = photoRepository.saveAll(photoEntities);
        return photoDTOs;
    }
}
