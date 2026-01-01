export default function ProductBlock({productTitle, productPrice}){//, productSourceImage}){
    //const image = require('../../images/' + productSourceImage);
    //<img className={classes['product-image']} src={image} alt='Error' />
    
   return (
    <div className="w-72 h-85 px-4 pt-5 pd-15 m-2 bg-gray-200 rounded-2xl">
        <p className="text-2xl m-0">{productTitle}</p>
        <p className="text-3xl m-0">{productPrice}</p>
    </div>
   );
}