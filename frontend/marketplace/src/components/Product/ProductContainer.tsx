import ProductBlock from "./ProductBlock.tsx"

interface Product{
    id: number;
    title: string;
    price: number;
}

interface ProductContainerProps{
    products: Product[];
}

export default function ProductContainer({ products }: ProductContainerProps ){
    return (
        <div className="flex justify-center">
            <div className="w-300 h-dvh flex flex-wrap">
                {products.map((product: Product) => <ProductBlock 
                    key={product.id}
                    productTitle={product.title}
                    productPrice={product.price}
                />)}
            </div>
        </div>
    );
}