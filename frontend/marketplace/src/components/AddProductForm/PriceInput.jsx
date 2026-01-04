export default function PriceInput(){
    return (
        <div className="flex justify-between w-50 my-7">
            <div className="flex text-2xl mr-1 text-gray-600">$</div>
            <input
                type="number"
                name="price"
                min="0"
                max="999999999"
                placeholder="Ціна"
                required
                className="flex w-50 h-10 text-2xl outline-none border
                    border-gray-400 focus:border-cyan-500 [appearance:textfield]"
            />
        </div>
    );
}