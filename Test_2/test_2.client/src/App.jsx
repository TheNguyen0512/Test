import { useEffect, useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSortUp, faSortDown } from '@fortawesome/free-solid-svg-icons';
import './App.css';

function App() {
    const [customers, setCustomers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [loadingAnimation, setLoadingAnimation] = useState(false);
    const [error, setError] = useState(null);
    const [networkError, setNetworkError] = useState(false);
    const [sortOrder, setSortOrder] = useState({
        customerID: null,
        companyName: null,
        contactName: null,
        contactTitle: null,
        country: null,
    });
    const [searchResults, setSearchResults] = useState([]);
    const [searchNotFound, setSearchNotFound] = useState(false);
    const [searchQuery, setSearchQuery] = useState('');

    useEffect(() => {
        populateCustomerData();
    }, []);

    const handleSearchInputChange = (event) => {
        const query = event.target.value;
        setSearchQuery(query);
        if (query.trim() === '') {
            setSearchNotFound(false);
            setCustomers([]);
            populateCustomerData();
        }
    };

    const handleSearchClick = () => {
        searchCustomers(searchQuery);
    };

    const renderContent = () => {
        const displayCustomers = searchResults.length > 0 ? searchResults : customers;

        if (loading || loadingAnimation) {
            return (
                <div>
                    <p><em>Loading... Please wait.</em></p>
                    {loadingAnimation && <div className="loading-animation"></div>}
                </div>
            );
        } else if (error || networkError) {
            return (
                <div>
                    <p>Error: {error ? error.message : 'Network error'}</p>
                    {networkError && (
                        <button onClick={retryFetch}>Retry</button>
                    )}
                </div>
            );
        } else if (displayCustomers.length === 0 && searchQuery.trim() !== '') {
            return (
                <div>
                    <p>Not found.</p>
                    <button onClick={() => {
                        setSearchQuery('')
                        setSearchNotFound(false); // Đặt searchNotFound về false
                        populateCustomerData(); // Tải lại dữ liệu khách hàng                    
                    }}>Back</button> </div>
            );
        } else {
            return (
                <div>
                    <div className="search-container">
                        <input type="text" className="search-input" placeholder="Search..." value={searchQuery} onChange={handleSearchInputChange} />
                        <button className="search-button" onClick={handleSearchClick}>Search</button>
                    </div>
                    {searchNotFound && (
                        <div>
                            <p>No results found.</p>
                            <button onClick={() => {
                                setSearchQuery('');
                                setSearchNotFound(false); // Đặt searchNotFound về false
                                populateCustomerData(); // Tải lại dữ liệu khách hàng
                            }}>Back</button>
                        </div>
                    )}
                    <table className={`custom-table ${searchNotFound ? 'hidden' : ''}`}>
                        <thead>
                            <tr>
                                <th onClick={() => sortCustomers('customerID')}>
                                    Customer ID {sortOrder.customerID === 'asc' ? <FontAwesomeIcon icon={faSortUp} /> : sortOrder.customerID === 'desc' ? <FontAwesomeIcon icon={faSortDown} /> : null}
                                </th>
                                <th onClick={() => sortCustomers('companyName')}>
                                    Company Name {sortOrder.companyName === 'asc' ? <FontAwesomeIcon icon={faSortUp} /> : sortOrder.companyName === 'desc' ? <FontAwesomeIcon icon={faSortDown} /> : null}
                                </th>
                                <th onClick={() => sortCustomers('contactName')}>
                                    Contact Name {sortOrder.contactName === 'asc' ? <FontAwesomeIcon icon={faSortUp} /> : sortOrder.contactName === 'desc' ? <FontAwesomeIcon icon={faSortDown} /> : null}
                                </th>
                                <th onClick={() => sortCustomers('contactTitle')}>
                                    Contact Title {sortOrder.contactTitle === 'asc' ? <FontAwesomeIcon icon={faSortUp} /> : sortOrder.contactTitle === 'desc' ? <FontAwesomeIcon icon={faSortDown} /> : null}
                                </th>
                                <th>Address</th>
                                <th>City</th>
                                <th>Region</th>
                                <th>Postal Code</th>
                                <th onClick={() => sortCustomers('country')}>
                                    Country{sortOrder.country === 'asc' ? <FontAwesomeIcon icon={faSortUp} /> : sortOrder.country === 'desc' ? <FontAwesomeIcon icon={faSortDown} /> : null}
                                </th>
                                <th>Phone</th>
                                <th>Fax</th>
                            </tr>
                        </thead>
                        <tbody>
                            {displayCustomers.map(customer => (
                                <tr key={customer.CustomerID}>
                                    <td>{customer.CustomerID}</td>
                                    <td>{customer.CompanyName}</td>
                                    <td>{customer.ContactName}</td>
                                    <td>{customer.ContactTitle}</td>
                                    <td>{customer.Address}</td>
                                    <td>{customer.City}</td>
                                    <td>{customer.Region}</td>
                                    <td>{customer.PostalCode}</td>
                                    <td>{customer.Country}</td>
                                    <td>{customer.Phone}</td>
                                    <td>{customer.Fax}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            );
        }
    };


    const sortCustomers = async (column) => {
        setLoading(true);
        setLoadingAnimation(true);
        try {
            const response = await fetch(`https://localhost:7134/api/customers/SortedBy${column.charAt(0).toUpperCase() + column.slice(1)}${sortOrder[column] === 'asc' ? 'Asc' : 'Desc'}`);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();
            setCustomers(data);
            setSortOrder(prevSortOrder => ({
                ...prevSortOrder,
                [column]: prevSortOrder[column] === 'asc' ? 'desc' : 'asc'
            }));
        } catch (error) {
            console.error('Error fetching sorted customer data:', error);
            setError(error);
            setNetworkError(true);
        } finally {
            setLoading(false);
            setLoadingAnimation(false);
        }
    };

    const retryFetch = () => {
        setNetworkError(false);
        populateCustomerData();
    };

    const searchCustomers = async (query) => {
        setLoading(true);
        setLoadingAnimation(true);
        try {
            let apiUrl = 'https://localhost:7134/api/customers';
            if (query.trim() !== '') {
                apiUrl = `https://localhost:7134/api/customers/Search?query=${query}`;
            }
            const response = await fetch(apiUrl);
            if (!response.ok) {
                if (response.status === 404) {
                    // Nếu không tìm thấy, set dữ liệu tìm kiếm là rỗng và không hiển thị thông báo lỗi
                    setSearchResults([]);
                    setSearchNotFound(true);
                } else {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
            } else {
                const data = await response.json();
                setSearchResults(data);
                setSearchNotFound(data.length === 0);
            }
        } catch (error) {
            console.error('Error fetching search results:', error);
            setError(error);
            setNetworkError(true);
        } finally {
            setLoading(false);
            setLoadingAnimation(false);
        }
    };

    async function populateCustomerData() {
        setLoading(true);
        try {
            const response = await fetch('https://localhost:7134/api/customers');
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            const data = await response.json();
            setCustomers(data);
        } catch (error) {
            console.error('Error fetching customer data:', error);
            setError(error);
            setNetworkError(true);
        } finally {
            setLoading(false);
        }
    }

    return (
        <div className="container">
            <h1>Customer List</h1>
            {renderContent()}
        </div>
    );
}

export default App;
