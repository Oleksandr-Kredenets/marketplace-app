import {useState, useEffect} from 'react';
import ProductContainer from './components/Product/ProductContainer.tsx';
import AddButton from './components/AddProductForm/AddButton.tsx';
import AddForm from './components/AddProductForm/AddForm.tsx';

interface Product{
    id: string;
    title: string;
    price: number;
    imageUrl: string;
}

export default function App() {
    const [products, setProducts] = useState<Product[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [addFormActive, setAddFormActive] = useState<boolean>(false);

    // Fetch data to backend
    useEffect( () => {
        const fetchData = async () => {
            try {
                fetch('http://localhost:5011/products')
                .then((response) => {
                    return response.json();
                })
                .then((result) => {
                    setProducts(result.value);
                });
            } catch (error) {
                console.log(`[!] Error of loading\n${error}`);
            } finally {
                setIsLoading(false);
            }
        };
        fetchData();
    }, []);

    // Loading bar
    if (isLoading)
        return (
            <div className="flex justify-center items-center h-screen">
                <div className="border-8 h-16 w-16 rounded-4xl border-cyan-400 
                border-t-white animate-spin"/>
            </div>
        );

    // Main app
    return (
        <div className="flex justify-center items-center">
            {/*??? images ??? */}
            <ProductContainer products={products}/>
            <AddButton onClick={() => setAddFormActive(!addFormActive)}/>
            <AddForm isActive={addFormActive} setFormActive={setAddFormActive}/>
        </div>
    );
}