import {useState, useEffect} from 'react';
import photo from '../../assets/images/gallery-photo.svg';

export default function ImageInput(){
    const [previewUrl, setPreviewUrl] = useState(null);
    
    // Set file url
    const handleFileChange = (event) => {
        const file = event.target.files[0];
        if (file){
            const url = URL.createObjectURL(file);
            setPreviewUrl(url);
        }
        else setPreviewUrl(null);
    }

    // Memory optimization
    useEffect(() =>{
        return () => {
            if (previewUrl) URL.revokeObjectURL(previewUrl);
        }
    }, [previewUrl]);

    console.log(previewUrl);
    return (
        <>
            <div className="absolute left-20 top-25 h-85 w-85 rounded-2xl
            bg-gray-200"/>
            {!previewUrl && (
                <img
                    src={photo}
                    className="absolute left-20 top-25 h-85 w-85"
                />
            )}
            {previewUrl && (
                <img
                    src={previewUrl}
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