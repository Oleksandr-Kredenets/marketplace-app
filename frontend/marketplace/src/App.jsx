import {useState, useEffect} from 'react';
import ProductContainer from './components/Product/ProductContainer';

export default function App() {
    const [products, setProducts] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect( () => {
        const fetchData = async () => {
            try {
                const response = await fetch('http://localhost:5011/products');
                const result = await response.json();
                setProducts(result.value);
            } catch (error) {
                console.log(`[!] Error of loading\n${error}`);
            } finally {
                setIsLoading(false);
            }
        };
        fetchData();
    }, []);

    if (isLoading)
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="border-8 h-16 w-16 rounded-4xl border-cyan-400 border-t-white animate-spin"/>
            </div>
        );
    return (
        <div className="flex justify-center">
                {/*??? images ??? */}
                <ProductContainer products={products} />
        </div>
    );
   
}