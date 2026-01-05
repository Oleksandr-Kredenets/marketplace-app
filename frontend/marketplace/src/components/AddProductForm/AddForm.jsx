import Cross from '../main/Cross';
import PriceInput from './PriceInput';
import DescriptionInput from './DescriptionInput';
import ImageInput from '../main/ImageInput';

export default function AddForm({isActive, setFormActive}){
    if (isActive) return (
        <div className="fixed inset-0 flex justify-center items-center bg-black/25">
            <form
            method="post"
            action="http://localhost:5011/products"
            className="bg-white relative p-6 h-150 w-300 rounded-lg">
                <Cross set={setFormActive}/>
                <ImageInput/>
                <div className="absolute right-20 h-170 w-150 ">
                    <input
                        type="text"
                        name="title"
                        placeholder="Назва товару"
                        className="input-text h-12 w-120 text-2xl mb-4 mt-25"
                    />
                    
                    <PriceInput/>
                    <DescriptionInput/>
                </div>
                <button
                    type="submit"
                    className="bg-cyan-500 text-white rounded-2xl w-50 h-15 
                            absolute right-1/2 bottom-10 cursor-pointer"
                >Додати</button>
            </form> 
        </div>
    );
}