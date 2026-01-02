export default function AddForm({isActive}){
    if (isActive) return (
        <div className="fixed inset-0 flex justify-center items-center bg-black/25">
            <form className="bg-white relative p-6 h-200 w-350 rounded-lg">
                <input type="text" id="name" placeholder="Назва товару"
                className="input-text absolute right-40 top-25 h-15 w-120 text-2xl" />
                <input type="text" className="input-text flex"/>
            </form> 
        </div>
    );
}