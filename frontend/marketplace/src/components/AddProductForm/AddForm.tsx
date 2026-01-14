import {useState} from 'react';
import Cross from '../main/Cross';
import PriceInput from './PriceInput';
import DescriptionInput from './DescriptionInput';
import ImageInput from '../main/ImageInput';

interface AddFormProps{
    isActive: boolean;
    setFormActive: Function;
}

export default function AddForm({isActive, setFormActive}: AddFormProps){
    const [productTitle, setProductTitle] = useState<string>("");
    const [productPrice, setProductPrice] = useState<string>("");
    const [productDescription, setProductDescription] = useState<string>("");

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const data = {
            UserId: "3e192f73-0ef6-43be-b2f5-cf2708f803ad",
            Title: productTitle,
            Price: Number(productPrice),
            Description: productDescription
        };

        await fetch("http://localhost:5011/products", {
            method: "POST",
            headers:{ "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        setFormActive(false);
    };

    if (isActive) return (
        <div className="fixed inset-0 flex justify-center items-center bg-black/25">
            <form
            method="post"
            onSubmit={handleSubmit}
            className="bg-white relative p-6 h-150 w-300 rounded-lg">
                <Cross set={setFormActive}/>
                <ImageInput/>
                <div className="absolute right-20 h-170 w-150 ">
                    <input
                        type="text"
                        name="title"
                        value={productTitle}
                        onChange={(e)=>setProductTitle(e.target.value)}
                        placeholder="Назва товару"
                        className="input-text h-12 w-120 text-2xl mb-4 mt-25"
                    />
                    
                    <PriceInput
                        value={productPrice}
                        onChange={(e)=>setProductPrice(e.target.value)}
                    />
                    <DescriptionInput
                        value={productDescription}
                        onChange={(e)=>setProductDescription(e.target.value)}
                    />
                </div>
                <button
                    type="submit"
                    className="bg-cyan-500 text-white rounded-2xl w-50 h-15 
                            absolute left-1/2 -translate-x-1/2 bottom-10 cursor-pointer"
                >Додати</button>
            </form> 
        </div>
    );
}