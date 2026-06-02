import {useState, useEffect} from 'react';
import { Dispatch, SetStateAction } from 'react';
import photo from '../../assets/images/gallery-photo.svg';

interface ImageInputProps{
    img: string | null;
    onChange: Dispatch<SetStateAction<string | null>>; 
    onFileChange: Dispatch<SetStateAction<File | null>>;
}

export default function ImageInput({img, onChange, onFileChange} : ImageInputProps){
    // Set file url
    const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const files = event.target.files;
        if (files && files.length > 0){
            onFileChange(files[0]);
            const url = URL.createObjectURL(files[0]);
            onChange(url);
        }
        else {
            onChange(null);
            onFileChange(null);
        }
    }

    // Memory optimization
    useEffect(() =>{
        return () => {
            if (img) URL.revokeObjectURL(img);
        }
    }, [img]);

    return (
        <>
            <div className="absolute left-20 top-25 h-85 w-85 rounded-2xl
            bg-gray-200"/>
            {!img && (
                <img
                    src={photo}
                    className="absolute left-20 top-25 h-85 w-85"
                />
            )}
            {img && (
                <img
                    src={img}
                    alt="Preview"
                    className="absolute left-20 top-25 h-85 w-85"
                />
            )}
            <input
                type="file"
                accept=".jpg, .jpeg, .png"
                id="fileInput"
                className="absolute h-85 w-85 left-20 top-25 opacity-0 cursor-pointer"
                onChange={handleFileChange}
            />
        </>
    )
}