export default function AddForm({isActive}){
    if (isActive) return (
        <div className="fixed inset-0 flex justify-center items-center bg-black/25">
            <form className="bg-white relative p-6 h-200 w-350 rounded-lg">
                <input type="file"></input>

                <div className="absolute right-20 h-170 w-150 bg-amber-400">
                    <input type="text" name="title" placeholder="Назва товару" required
                    className="input-text h-12 w-120 text-2xl mb-4" />

                    <div className="flex justify-between w-50">
                        <div className="flex text-2xl mr-1 text-gray-600">$</div>
                        <input type="number" name="price" min="0" max="999999999"
                        placeholder="Ціна" required
                        className="flex w-50 h-10 text-2xl outline-none border-b-2 mb-4
                        border-b-gray-400 focus:border-b-cyan-500 [appearance:textfield]"/>
                    </div>

                    <input type="text" placeHolder="Опис"
                    className="input-text w-50 h-10 text-2xl"/>
                </div>
                <button type="submit" className="bg-cyan-500 text-white
                rounded-2xl w-50 h-15 absolute right-1/2 bottom-10">
                    Додати
                </button>
            </form> 
        </div>
    );
}