import { useState } from 'react';

export default function SortBar(){
    const [sortOption, setSortOption] = useState('ta');
    
    function handleChange(e: any){
        const selectedOptions = e.target.value;
        setSortOption(selectedOptions);

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }

    return (
        <select value={sortOption} onChange={handleChange}>
            <option value='title ascending'>За назвою за алфавітним порядком</option>
            <option value='title descending'>За назвою проти алфавітного порядку</option>
            <option value='price ascending'>За ціною від дешевих до дорожчих</option>
            <option value='price descending'>За ціною від дорожчих до дешевих</option>
        </select>
    )
}