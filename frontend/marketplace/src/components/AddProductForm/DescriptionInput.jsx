export default function DescriptionInput(){
    return (
        <textarea
            name="description"
            placeholder="Опис"
            className="border border-gray-600 focus:border-cyan-500 rounded
                outline-none w-full resize-none min-h-25 h-auto my-7"
            onInput={(e) =>{
                e.target.style.height = e.target.scrollHeight + 'px';
            }}/>
    );
}