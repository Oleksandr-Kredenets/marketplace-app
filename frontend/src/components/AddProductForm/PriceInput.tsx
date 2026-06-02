interface PriceInputProps {
    value: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

export default function PriceInput({value, onChange}: PriceInputProps){
    return (
        <div className="flex justify-between w-50 my-7">
            <div className="flex text-2xl mr-1 text-gray-600">$</div>
            <input
                type="number"
                name="price"
                placeholder="Ціна"
                value={value}
                onChange={onChange}
                min="0"
                max="999999999"
                required
                className="flex w-50 h-10 text-2xl outline-none border
                    border-gray-400 focus:border-cyan-500 [appearance:textfield]"
            />
        </div>
    );
}