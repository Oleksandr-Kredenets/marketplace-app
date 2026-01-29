interface ProductFunctionBarProps{
    id: string;
    isActive: boolean;
}

export default function ProductFunctionBar({id, isActive}: ProductFunctionBarProps){
    const onClickDeleteProduct = async () => {
        await fetch(`http://localhost:5011/products/${id}`, {
            method: "DELETE"
        })
        window.location.reload();
    }

    if (isActive){
        return (
            <div
                id={id.toString()}
                className="absolute h-30 w-50 bg-gray-100 left-70 z-50 rounded ">
                    <button className="flex items-center justify-center border
                    border-gray-400 h-10 text-green-500 cursor-pointer w-full
                    hover:bg-gray-200 rounded-t function-menu-trigger">
                        Додати в кошик
                    </button>
                    <button className="flex items-center justify-center border border-t-0
                    border-gray-400 cursor-pointer w-full h-10 hover:bg-gray-200
                    function-menu-trigger">
                        Редагувати
                    </button>
                    <button
                    onClick={onClickDeleteProduct} 
                    className="flex items-center justify-center border border-t-0
                    border-gray-400 text-red-500 cursor-pointer w-full h-10
                    hover:bg-gray-200 rounded-b function-menu-trigger">
                        Видалити
                    </button>
            </div>
        );
    }
}