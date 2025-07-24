package com.photoselect.api.Entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.UUID;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "tbl_photo")
public class PhotoEntity {
    @Id
    private UUID id;

    private String fileName;

    private String storagePath;

}
