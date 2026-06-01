interface moreButtonProps{
    setIsActive: () => void;
}

export default function MoreButton({setIsActive}: moreButtonProps){
    return (
        <button
        onClick={setIsActive}
        className="absolute top-3 cursor-pointer right-1">
            <div className="h-9 w-7 function-menu-trigger">
                <div className="border-3 border-white rounded-2xl absolute left-1/2
                -translate-x-1/2 top-2" />
                <div className="border-3 border-white rounded-2xl absolute left-1/2
                -translate-x-1/2 top-4" />
                <div className="border-3 border-white rounded-2xl absolute left-1/2
                -translate-x-1/2 top-6" />
            </div>
        </button>
    )
}