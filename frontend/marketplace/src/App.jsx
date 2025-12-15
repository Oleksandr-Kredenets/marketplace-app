import { useState } from 'react';
import ProductContainer from './components/Product/ProductContainer';
import productsData from './data/Products.json';

export default function App() {
  const [name, setName] = useState('name');

  return (
    <div className="container">
      <main>
        <ProductContainer products={productsData.products} />
            
        {/* <form>
          <input
            type="text"
            id="name"
            value={name}form
            onChange={(event) => setName(event.target.value)}
          /> 
        </form> */}
      </main>
    </div>
  );
}
