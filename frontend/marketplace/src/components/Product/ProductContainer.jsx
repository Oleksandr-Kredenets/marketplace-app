import ProductBlock from "./ProductBlock"
import classes from './ProductContainer.module.css'

export default function ProductContainer({ products }){
    return (
        <div className={`${classes['product-container']}`}>
            {products.map(product => <ProductBlock 
                key={product.id}
                productName={product.name}
                productPrice={product.price}
                productSourceImage={product.image}
            />)}
        </div>
    )
}