interface moreButtonProps{
    setIsActive: () => void;
}

export default function MoreButton({setIsActive}: moreButtonProps){
    return (
        <button
        onClick={setIsActive}
        className="absolute top-3 right-2 cursor-pointer">
            <div className="h-9 w-7 function-menu-trigger">
                <div className="border-2 border-black rounded-2xl absolute left-1/2
                -translate-x-1/2 top-2" />
                <div className="border-2 border-black rounded-2xl absolute left-1/2
                -translate-x-1/2 top-4" />
                <div className="border-2 border-black rounded-2xl absolute left-1/2
                -translate-x-1/2 top-6" />
            </div>
        </button>
    )
}