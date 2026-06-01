import { useState, useEffect } from "react";
import ProductBlock from "./ProductBlock.tsx";

interface Product{
    id: string;
    title: string;
    price: number;
    imageUrl: string;
}

interface ProductContainerProps{
    products: Product[];
}

export default function ProductContainer({ products }: ProductContainerProps ){
    const [isActiveFuncBarId, setIsActiveFuncBarId] = useState<string | null>(null);

    useEffect(() => {
        const clickHandlerOutside = (event: MouseEvent) => {
            const target = event.target as HTMLElement;
            const isClickedOutside = !target.closest('.function-menu-trigger');

            if (isClickedOutside){
                setIsActiveFuncBarId(null);
            }
        };
        document.addEventListener("mousedown", clickHandlerOutside);
        return () => document.removeEventListener("mousedown", clickHandlerOutside);
    }, []);

    return (
        <div className="w-304 h-dvh flex flex-wrap">
            {products.map((product: Product) => <ProductBlock 
                id = {product.id}
                key={product.id}
                title={product.title}
                price={product.price}
                imageUrl={product.imageUrl}
                isActiveFuncBarId={isActiveFuncBarId}
                setIsActiveFuncBarId={setIsActiveFuncBarId}
            />)}
        </div>
    );
}