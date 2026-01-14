interface DescriptionInputProps {
    value: string;
    onChange: React.ChangeEventHandler<HTMLTextAreaElement>;
}

export default function DescriptionInput({value, onChange}: DescriptionInputProps){
    return (
        <textarea
            name="description"
            placeholder="Опис"
            value={value}
            onChange={onChange}
            className="border border-gray-600 focus:border-cyan-500 rounded
                outline-none w-full resize-none min-h-25 h-auto my-7"
            onInput={(e: React.FormEvent<HTMLTextAreaElement>) => {
                const target = e.currentTarget as HTMLTextAreaElement;
                target.style.height = target.scrollHeight + 'px';
            }}/>
    );
}