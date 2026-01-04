export default function Cross({set}){
    return (
        <button
            onClick={() => set(false)}
            className="text-4xl absolute
                right-6 top-3 cursor-pointer"
        >×</button>
    )
}