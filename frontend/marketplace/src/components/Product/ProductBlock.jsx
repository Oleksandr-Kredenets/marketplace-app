import classes from './ProductBlock.module.css'

export default function ProductBlock({productName, productPrice, productSourceImage}){
    const image = require('../../images/' + productSourceImage);
    return (
        <div className={classes['main-block']}>
            <img className={classes['product-image']} src={image} alt='Error' />
            <p className={classes['product-name']}>{productName}</p>
            <p className={classes['product-price']}>{productPrice}</p>
        </div>
    )
}