import {useState, useEffect} from 'react';
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

    return (
        <>
            <div className="absolute left-40 top-35 h-85 w-85 bg-gray-200"/>
            {previewUrl && (
                <img
                    src={previewUrl}
                    alt="Preview"
                    className="absolute left-40 top-35 h-85 w-85"
                />
            )}
            <input
                type="file"
                accept=".jpg, .jpeg, .png"
                id="fileInput"
                className="absolute h-85 w-85 left-40 top-35 opacity-0 cursor-pointer"
                onChange={handleFileChange}
            />
        </>
    )
}