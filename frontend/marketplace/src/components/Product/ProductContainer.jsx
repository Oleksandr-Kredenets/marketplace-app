import ProductBlock from "./ProductBlock"

export default function ProductContainer({ products }){

    return (
        <div className="flex justify-center">
            <div className="w-300 h-dvh flex flex-wrap">
                {products.map(product => <ProductBlock 
                    key={product.id}
                    productTitle={product.title}
                    productPrice={product.price}
                />)}
            </div>
        </div>
    );
}